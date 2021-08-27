# frozen_string_literal: true

require_relative '../coffee_place'
require_relative './cli_parser'

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

      x_lat, y_lon, place_name = cli_opts.remaining

      puts <<~MSG
        Not yet implemented, work in progress!
        x = #{x_lat}, y = #{y_lon}, place_name = #{place_name}
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
