# frozen_string_literal: true

module SpecHelpers
  # Take floating point precision errors into account
  def be_almost_eq(value)
    be_within(0.0001).of(value)
  end
end
