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
      cli_opts = parse_cli_options!(args)

      show_help_and_exit! if cli_opts.print_help?
      show_version_and_exit! if cli_opts.show_version?

      user_location = validate_user_location!(cli_opts)
      locations = import_locations_from!(cli_opts)

      search = Search.new(locations)
      closest_locations = search.find_closest_to(user_location, cli_opts.num_results)

      display_closest_locations(closest_locations)
    end

    private

    def parse_cli_options!(args)
      result = @parser.parse(args)
      show_help_and_exit!(exit_status: 1) unless result.success?

      cli_opts = result.value

      # We must have [lat, lon, filename] as args
      unless cli_opts.num_args == 3
        puts 'Incorrect number of CLI arguments passed in'
        show_help_and_exit!(exit_status: 1)
      end

      cli_opts
    end

    def validate_user_location!(cli_opts)
      lat, lon = cli_opts.remaining
      location_result = Location.validate(lat: lat, lon: lon, name: 'Current user')

      if location_result.success?
        location_result.value
      else
        puts "Failure: #{location_result.error}"
        show_help_and_exit!(exit_status: 1)
      end
    end

    def import_locations_from!(cli_opts)
      source_name = cli_opts.source_name
      locations_result = @importer.import_from(source_name)

      if locations_result.success?
        locations_result.value
      else
        puts "Failed to import locations from: #{source_name.inspect}"
        print_errors_and_exit!(locations_result.error)
      end
    end

    def display_closest_locations(locations)
      locations.each do |distance, location|
        puts "#{location.name},#{distance.round(4)}"
      end
    end

    def show_help_and_exit!(exit_status: 0)
      @parser.show_help
      exit exit_status
    end

    def show_version_and_exit!(exit_status: 0)
      puts CoffeePlace::VERSION
      exit exit_status
    end

    def print_errors_and_exit!(errors)
      Array(errors).each do |error|
        puts error
      end

      exit 1
    end
  end
end
