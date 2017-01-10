# Order Pizza

## Description

Your task is to process a pizza order.
The order is consisted of a sentence.

The sentence obeys the following rules:
  - The sentence will start with the word `Iskam` and end with `.`
  - Words will be separated by whitespace (spaces, tabs, new lines)
  - Each pizza will be given by name
    - names can contain whitespace
	- names are case-insensitive
    - _Example:_ `Iskam vegetarianska.`
  - The `pizza` keyword may be used, just ignore it
    - _Examples:_
	  - `Iskam pizza vegetarianska.`
	  - `Iskam vegetarianska pizza.`
  - Several pizzas of one kind can be requested with a number before the pizza name
    - _Example:_ `Iskam 2 vegetarianska.`
  - Products can be excluded from a pizza using the `bez <product>` words
	- product names can contain whitespace
    - product names are case-insensitive
    - _Examples:_
	  - `Iskam vegetarianska bez domaten sos.`
	  - `Iskam 2 vegetarianska bez kashkaval.` - excluded from both
	  - `Iskam 3 vegetarianska 2 bez chushki.` - excluded from 2 of the 3 pizzas
	  - `Iskam vegetarianska bez domaten sos bez chushki.` - excluding several products
	  - `Iskam 2 vegetarianska 1 bez domaten sos bez kashkaval.` - excluding multiple products from one pizza
	  - `Iskam 2 vegetarianska 1 bez luk 1 bez tsarevitsa.` - excluding products from different pizzas
  - Different types of pizza can be ordered separated by `,` or `i`
    - _Example:_ `Iskam karbonara, barbekyu pile i formadzhi.`

Find the quantity of each product needed for the order. Print each product as:
```
chushki: 100g
```
Products should be printed in lexicographical order.

[Here is a menu.](./menu.md) In addition to the menu, all pizzas need **256g** **testo** and no one will want a pizza **bez testo**.

## Input
- Input is read from the console
  - One sentence, possibly on a several lines ending with a dot (`.`)

## Output
- Output should be printed on the console
  - All needed products and quantities, each product on a separate line

## Constraints
- **Time limit**: **0.1s**
- **Memory limit**: **16 MB**

## Sample tests

### Sample test 1

#### Input
```
Iskam Peperoni Klasik bez peperoni.
```

#### Output
```
domaten sos: 105g
motsarela: 98g
testo: 256g
```

### Sample test 2

#### Input
```
Iskam 1 pizza vita i 1 chikenita bez domati.
```

#### Output
```
beybi spanak: 147g
domaten sos: 89g
emental: 79g
krave sirene: 28g
motsarela: 114g
peperoni: 166g
pileshko file: 199g
presni domati: 55g
testo: 512g
```

### Sample test 3

#### Input
```
Iskam 2 prima  vera 1 bez gabi i 3 garda
  2 bez chushki 1 bez maslini.
```

#### Output
```
bosilek: 8g
chushki: 113g
domaten sos: 504g
domati: 44g
gabi: 44g
kashkaval: 415g
maslini: 302g
pileshko role: 321g
pusheno sirene: 591g
shunka: 52g
testo: 1280g
zehtin: 128g
```
