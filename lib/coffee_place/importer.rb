# frozen_string_literal: true

require 'csv'
require 'open-uri'

require_relative './result'
require_relative './location'

module CoffeePlace
  # Imports locations from local or remote CSV file.
  class Importer
    def initialize
      @locations = []
      @errors = []
    end

    def import_from(source_name)
      line_index = 0

      with_source(source_name) do |csv|
        CSV.parse(csv) do |line|
          line_index += 1
          import_line(line, line_index)
        end
      end

      location_results
    end

    def import_line(line, line_index)
      place_name, lat, lon = line
      location = Location.new(name: place_name, lat: lat, lon: lon)

      if location.valid?
        @locations << location
      else
        location.errors.each do |error|
          add_import_error "CSV error on line #{line_index}: #{error}"
        end
      end
    end

    def location_results
      if @errors.empty?
        Result.success(@locations)
      else
        Result.failure(@errors)
      end
    end

    def with_source(source_name, &block)
      uri = URI.parse(source_name)

      # When we have an URL, download remote file
      return with_remote_file(uri, &block) if uri.scheme

      # When we have a local file, try to open it
      return with_local_file(uri, &block) if File.exist?(uri.path)

      add_import_error unknown_source_error_message(source_name)
    rescue URI::InvalidURIError
      add_import_error "#{source_name} is not a valid URL or local filename"
    end

    def with_remote_file(uri, &block)
      uri.open(&block)
    rescue OpenURI::HTTPError => e
      add_import_error "Failed to download remote file \"#{uri}\": #{e.message}"
    end

    def with_local_file(uri, &block)
      File.open(uri.path, &block)
    rescue StandardError => e
      add_import_error "Failed to read local file \"#{uri.path}\": #{e.message}"
    end

    def unknown_source_error_message(source_name)
      <<~ERROR
        Don't know how to import locations from: #{source_name.inspect}
        Make sure the URL or filename is not misstyped.
      ERROR
    end

    def add_import_error(message)
      @errors << message
    end
  end
end
