import random

number = 10

array = [random.randint(0, 20) for ind in range(5)]
print(array)

generator = [num for num in array if num > number]
print(generator)