# Laboratory Work No.3 - Structural Design Patterns

A C# console application, a "bakery", that implements three structural design patterns (**Composite**, **Decorator** and **Flyweight**) on top of the creational patterns of the previous laboratory work (Factory Method, Abstract Factory and Builder).

The customer chooses products from three shops, adds toppings to them, packs them into gift boxes and views the whole order with its weight, calories and allergens.

The full description of the patterns, class diagrams and test results is in [`report-lab3.md`](report-lab3.md).

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Optional: JetBrains Rider or Visual Studio (the solution file is `Lab3.sln`)

## Project layout

```
Lab3/                 solution folder (run the commands below from here)
├── Lab3.sln
├── Lab3/             console application
├── TestLab3/         NUnit test project
├── docs/images/      screenshots used in the report
├── README.md
└── report-lab3.md
```

## Build

```
dotnet build
```

## Run

Interactive bakery:

```
dotnet run --project Lab3
```

Scripted demonstration of every pattern, without any input:

```
dotnet run --project Lab3 -- --demo
```

In Rider, select the `Lab3` run configuration and press **Run**.

### Using the interactive bakery

```
Main menu
  1) Order a product
  2) Make a gift box
  3) View my order
  4) Run the pattern demo
  0) Checkout and exit
```

- **Order a product**: choose a shop, then a product, then add toppings one by one (`0` = done). After each product the shop list is shown again, so several products can be ordered in a row; `0` at the shop list returns to the main menu.
- **Make a gift box**: give the box a name, then add products to it the same way (each with its own toppings). `0` at the shop list closes the box and adds it to the order. An empty box is not added.
- **View my order**: prints the order as a tree, with total weight, calories, allergens and the number of shared ingredient types in memory.
- **Run the pattern demo**: the same output as `--demo`, on a fresh set of shops.
- **Checkout and exit**: prints a short summary and closes the program.

Enter numbers only; any other input is rejected and the question is asked again.

## Test

```
dotnet test
```

This runs the 12 NUnit tests of `TestLab3` (four per pattern: `CompositeTests`, `DecoratorTests`, `FlyweightTests`).

In Rider, right-click `TestLab3` and choose **Run Unit Tests**.
