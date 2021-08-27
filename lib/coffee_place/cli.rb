# frozen_string_literal: true

require_relative '../coffee_place'
require_relative './cli_parser'
require_relative './location'

module CoffeePlace
  # Parses and runs CLI application using supplied args.
  class CLI
    attr_accessor :cli_opts, :parsed_args

    def initialize
      @parser = CLIParser.new
    end

    def run(args)
      result = @parser.parse(args)
      show_help_and_exit!(exit_status: 1) unless result.success?

      cli_opts = result.value
      show_help_and_exit! if cli_opts.print_help?
      show_version_and_exit! if cli_opts.show_version?

      lat, lon, place_name = cli_opts.remaining
      location_result = Location.validate(lat: lat, lon: lon, name: place_name)

      unless location_result.success?
        puts "Failure: #{location_result.error}"
        show_help_and_exit!(exit_status: 1)
      end

      location = location_result.value

      puts <<~MSG
        Not yet implemented, work in progress!
        #{location}
      MSG
    end

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
