import random

# Функция для генерации случаный целых чисел
# size - размер массива
# min - минимальный элемент в массиве
# max - максимальный элемент в массиве
def random_array(size, min, max): 
    array = []
    _size = size
    while _size:
        array.append(random.randint(min, max))
        _size -= 1

    return array

# Функция для вычисления суммы массива без учетая элементов после 13
def sum_without13(array):
    for i in range (len(array)):
        if array[i] == 13:
            array = array[:i]
            return sum(array)
    
    return sum(array)


array = random_array(4, 10, 15)
print(array)
print(sum_without13(array))