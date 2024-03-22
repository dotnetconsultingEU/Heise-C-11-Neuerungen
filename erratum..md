Leider ist mir bei den ListPattern (Demos\ListPatternsDemo.cs) ein Dreher passiert.

Statt 

```
    25: WriteLine($"2) {numbers is [1, .., 7]}"); // .. => Range Pattern, 1 Element
    26: WriteLine($"3) {numbers is [1, 3, _, 7, 9]}"); // _ => Discard Pattern, 0..n Elemente
```

müßte es heißen

```
    25: WriteLine($"2) {numbers is [1, .., 7]}"); // .. => Range Pattern, 0..n Elemente
    26: WriteLine($"3) {numbers is [1, 3, _, 7, 9]}"); // _ => Discard Pattern, 1 Element
```

Das Range Pattern erlaubt nicht nur 1 Element, sondern 0..n Element. Hingegen das Discard Pattern nur genau ein Element erlaubt.

Danke an den Finder!

Thorsten Kansy