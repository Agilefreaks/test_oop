# frozen_string_literal: true

module CoffeePlace
  # Keeps parsed CLI options, also defining defaults.
  class CLIOptions
    attr_accessor :version, :help, :remaining

    def initialize(version: false, help: false, remaining: [])
      @version = version
      @help = help
      @remaining = remaining
    end

    def show_version?
      @version
    end

    def print_help?
      @help
    end

    def <<(arg_value)
      @remaining << arg_value
    end
  end
end
