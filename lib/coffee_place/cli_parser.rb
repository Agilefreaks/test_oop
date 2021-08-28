# frozen_string_literal: true

require 'optparse'
require_relative '../coffee_place'
require_relative './result'
require_relative './cli_options'

module CoffeePlace
  # Parses CLI arguments into a `CLIOptions` instance.
  class CLIParser
    attr_accessor :cli_opts, :parsed_args

    def parse(args)
      # Make sure we are not modifying `args` directly
      args = args.clone

      @cli_opts = CLIOptions.new
      @opt_parser = build_args_parser
      @parsed_args = extract_free_standing_arguments(args)

      Result.success(@cli_opts)
    end

    def show_help
      puts @opt_parser
    end

    private

    # Since we are declaratively defining independent flags, method length isn't a concern
    #
    # rubocop:disable Metrics/MethodLength
    def build_args_parser
      OptionParser.new do |opts|
        opts.banner = CoffeePlace::BANNER

        opts.on('-h', '--help', 'Print this help message') do
          @cli_opts.help = true
        end

        opts.on('-v', '--version', 'Print version and exit') do
          @cli_opts.version = true
        end

        opts.on('-n[NUM]', '--num=[NUM]', 'Number of search results to return - default is 3') do |num|
          @cli_opts.num_results = num.to_i
        end
      end
    end
    # rubocop:enable Metrics/MethodLength

    # Sadly, ruby's OptParser does not like arguments that start with a minus sign,
    # as it interprets them as CLI command switches, e.g -122.4 raises OptionParser::InvalidOption
    #
    # This method catches `InvalidOption`, and gathers arguments that `optparser` can't parse.
    #
    # https://stackoverflow.com/questions/3642331/can-optionparser-skip-unknown-options-to-be-processed-later-in-a-ruby-program
    def extract_free_standing_arguments(args)
      @opt_parser.order!(args) do |unrecognized_opt|
        @cli_opts << unrecognized_opt
      end
    rescue OptionParser::InvalidOption => e
      # Push back unrecognized argument onto args so we can shift it afterwards
      e.recover(args)
      @cli_opts << args.shift

      retry
    end
  end
end
