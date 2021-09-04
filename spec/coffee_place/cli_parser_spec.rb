# frozen_string_literal: true

require 'coffee_place/cli_parser'

RSpec.describe CoffeePlace::CLIParser do
  subject(:parser) { described_class.new }

  describe '#parse' do
    it 'parses non flag arguments correctly' do
      result = subject.parse(['47.6', '-122.4', 'coffee_shops.csv'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.remaining).to eq(['47.6', '-122.4', 'coffee_shops.csv'])
      expect(cli_opts.version).to eq(false)
      expect(cli_opts.help).to eq(false)
    end

    it 'parses arguments correctly when flags are included' do
      result = subject.parse(['47.6', '-122.4', '--help', 'coffee_shops.csv'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.remaining).to eq(['47.6', '-122.4', 'coffee_shops.csv'])
      expect(cli_opts.version).to eq(false)
      expect(cli_opts.help).to eq(true)
    end

    it 'parses version flag correctly' do
      result = subject.parse(['--version'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.version).to eq(true)
      expect(cli_opts.help).to eq(false)
      expect(cli_opts.remaining).to be_empty
    end

    it 'parses version flag short flag correctly' do
      result = subject.parse(['-v'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.version).to eq(true)
      expect(cli_opts.help).to eq(false)
      expect(cli_opts.remaining).to be_empty
    end

    it 'parses print help message correctly' do
      result = subject.parse(['--help'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.version).to eq(false)
      expect(cli_opts.help).to eq(true)
      expect(cli_opts.remaining).to be_empty
    end

    it 'parses print help short message correctly' do
      result = subject.parse(['-h'])

      expect(result).to be_success

      cli_opts = result.value
      expect(cli_opts.version).to eq(false)
      expect(cli_opts.help).to eq(true)
      expect(cli_opts.remaining).to be_empty
    end
  end
end
