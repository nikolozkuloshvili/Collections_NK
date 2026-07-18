# Collections_NK

`Collections_NK` is a .NET 8 project that implements custom collection data structures and compares them with built-in .NET collections.

## What is included

- Non-generic collections:
  - `MyList`
  - `MyQueue`
  - `MyStack`
- Generic collections:
  - `MyGenericList<T>`
  - `MyGenericQueue<T>`
  - `MyGenericStack<T>`
- Linked lists:
  - `SingleLinkedList<T>`
  - `DoubleLinkedList<T>`
- Unit tests (xUnit)
- Benchmark suite (BenchmarkDotNet)

## Repository structure

- `/Collections_NK` – main implementation project
- `/Collections_NK.UnitTests` – unit tests for custom collections
- `/Collections_NK.Benchmarks` – performance benchmarks and benchmark outputs
- `Collections_NK.sln` – solution file

## Requirements

- .NET SDK 8.0+

## Build

```bash
dotnet build /home/runner/work/Collections_NK/Collections_NK/Collections_NK.sln
```

## Run tests

```bash
dotnet test /home/runner/work/Collections_NK/Collections_NK/Collections_NK.sln
```

## Run benchmarks

```bash
dotnet run --project /home/runner/work/Collections_NK/Collections_NK/Collections_NK.Benchmarks/Collections_NK.Benchmarks.csproj -c Release
```

Benchmark output can be found in:

- `/home/runner/work/Collections_NK/Collections_NK/Collections_NK.Benchmarks/Results/`

## Notes

- Capacity growth in custom array-backed collections uses doubling.
- Stack enumeration returns items in LIFO order.
- Linked list implementations expose node-based operations such as add-before/add-after and find/remove.
