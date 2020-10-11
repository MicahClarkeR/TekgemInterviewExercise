# Tekgem Interview Exercise
This program was written by Micah Clarke for a Tekgem job application as a junior software engineer, in accordance to the [speficiation](https://drive.google.com/file/d/1xfaymCunWYnvhgU1hYUUQKicLTS9lcpf/view?usp=sharing). For this, I wanted to explore and experiment with high-performance data structures. Combining knowledge gained through university and my own intuition. I wanted to experiment and learn some new skills, putting design patterns and my fascination with data structures to good use.

## City Tree
The ***City Tree*** forms the heart of the project. Formed using a collection of Sorted Dictionaries, by breaking up input data into a collection of characters and storing them into nested dictionaries. This forms a strong data structure, that will be used later for quick data validation, retrieval, and ease of access. This data structure creates a set of data, with no duplicates. The recursive nature of the code's structure makes it extremely easy to maintain.

## Weaknesses/Improvements/Considerations
Immediately, a database driver was considered to merge the the C# with a SQL database back-end. This would ensure a high performance, however for this project I wanted to keep all the code native without introducing an external database structure. I wanted to experiment and implement a new data structure I've not created thus far, the tree. Inspired by structures like the *binary tree* I wanted to utilize a similar structure but for string/character data. 
