import random
import string

def random_string(length):
    letters = string.ascii_lowercase
    rand_string = ''.join(random.choice(letters) for i in range(length))
    return rand_string

def check_chars(str1, str2):
    seen = set()
    for char in str1:
        seen.add(char)
    
    result = set()
    for char in str2:
        if char in seen:
            result.add(char)

    return result


str1 = random_string(5)
str2 = random_string(5)
print("Создадим две строки на 5 элементов:", str1, "и", str2)
print("Одинаковые символы:", ''.join(check_chars(str1, str2)))