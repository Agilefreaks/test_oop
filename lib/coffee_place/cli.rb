# frozen_string_literal: true

require_relative '../coffee_place'
require_relative './location'
require_relative './cli_parser'
require_relative './importer'
require_relative './search'

module CoffeePlace
  # Parses and runs CLI application using supplied args.
  class CLI
    attr_accessor :cli_opts, :parsed_args

    def initialize(parser: CLIParser.new,
                   importer: Importer.new)
      @parser = parser
      @importer = importer
    end

    def run(args)
      result = @parser.parse(args)
      show_help_and_exit!(exit_status: 1) unless result.success?

      cli_opts = result.value
      show_help_and_exit! if cli_opts.print_help?
      show_version_and_exit! if cli_opts.show_version?

      lat, lon, source_name = cli_opts.remaining
      location_result = Location.validate(lat: lat, lon: lon, name: 'Current user')

      unless location_result.success?
        puts "Failure: #{location_result.error}"
        show_help_and_exit!(exit_status: 1)
      end

      user_location = location_result.value
      locations_result = @importer.import_from(source_name)

      unless locations_result.success?
        puts "Failed to import locations from: #{source_name.inspect}"
        errors = Array(locations_result.error)

        errors.each do |error|
          puts error
        end
        return
      end

      locations = locations_result.value

      search = Search.new(locations)
      clossest_locations = search.find_closest_to(user_location)

      clossest_locations.each do |distance, location|
        puts "#{location.name},#{distance.round(4)}"
      end
    end

    private

    def show_help_and_exit!(exit_status: 0)
      @parser.show_help
      exit exit_status
    end

    def show_version_and_exit!(exit_status: 0)
      puts CoffeePlace::VERSION
      exit exit_status
    end
  end
end
