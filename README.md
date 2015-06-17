# Build status

[![Build Status](https://travis-ci.org/MHAbrah/PleaseBehave.svg?branch=master)](https://travis-ci.org/MHAbrah/PleaseBehave)

# PleaseBehave description

Please Behave is a simple behavior tree implementation.

# Node types

## Composites

- **Selector:** Succeeds if *any* of its child nodes succeed.
- **Sequence:** Runs its child nodes and succeeds if all child nodes succeed but fails if just one child node fails.

## Decorators

- **Inverter:** Takes its child's status and inverts a success to failure or a failure to success. Does not modify a running state.
- **Repeater:** Runs its children either for a specified number of repetitions or forever.
- **Succeeder:** Succeeds even if its child node fails. Treats a running node normally (as running).

## Leafs

- **Act:** A node that calls a Function (Func<bool>) on each tick until it returns true to indicate completion.
- **Condition:** Calls a Func and succeeds if the Func returns true, otherwise this node fails.
