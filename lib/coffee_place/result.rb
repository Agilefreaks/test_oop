# frozen_string_literal: true

module CoffeePlace
  Result = Struct.new(:success?, :value, :error) do
    def failure?
      !success?
    end

    class << self
      def success(value)
        new(true, value, nil)
      end

      def failure(error)
        new(false, nil, error)
      end
    end
  end
end
