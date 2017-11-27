# Notes About This Project

This is a C# starting point for the well known Gilded Rose kata. I've
specifically set it up so you can follow the flow of Sandi Metz's wonderful
["All The Little Things"](https://www.youtube.com/watch?v=8bZh5LMaSmE)
talk from RailsConf 2014.

One thing I really like about Sandi's talk is the practical use of the
cyclomatic complexity metric - probably the scariest name for one of the
clearest metrics we have (in my opinion) that measure the "cognitive overhead"
involved in understanding a piece of code.

The journey I'm illustrating starts with an implementation as "Legacy Code",
with no tests. I expect you to characterize the behaviour of the existing
implementation before starting on the implementation of the "Conjured" update.

## Steps to Use

1. Clone this repository; the `master` branch contains the starting point. Over
   time you may see me elaborate branches like `step0`, `step1` etc showing a
   particular journey of solution.
2. TBD: `npm install` - NuGet restore
3. TBD: `npm test` - VS Test
4. TBD: `npm run analyze` - Static Analysis, cyclomatic complexity how?

# Gilded Rose Requirements Specification

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime
location in a prominent city ran by a friendly innkeeper named Allison. We also
buy and sell only the finest goods. Unfortunately, our goods are constantly
degrading in quality as they approach their sell by date. We have a system in
place that updates our inventory for us. It was developed by a no-nonsense type
named Leeroy, who has moved on to new adventures. Your task is to add the new
feature to our system so that we can begin selling a new category of items.
First an introduction to our system:

- All items have a SellIn value which denotes the number of days we have to sell
  the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases in
  Quality
- "Backstage passes", like aged brie, increases in Quality as its SellIn value
  approaches;
  - Quality increases by 2 when there are 10 days or less and by 3 when there
    are 5 days or less but
  - Quality drops to 0 after the concert

We have recently signed a supplier of conjured items. This requires an update to
our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code 
as long as everything still works correctly. However, do not alter the Item 
class or Items property as those belong to the goblin in the corner who will 
insta-rage and one-shot you as he doesn't believe in shared code ownership (you 
can make the UpdateQuality method and Items property static if you like, we'll 
cover for you).

Just for clarification, an item can never have its Quality increase above 50, 
however "Sulfuras" is a legendary item and as such its Quality is 80 and it 
never alters.