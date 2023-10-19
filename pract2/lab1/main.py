import sqlite3

database = r"books.db"

sql_create_table = """
                    create table if not exists books(
                    number integer primary key autoincrement,
                    name string,
                    author string,
                    count integer
                    )"""

conn = sqlite3.connect(database)

c = conn.cursor()
c.execute(sql_create_table)

# Ручное добавление
c.execute("insert into books (name, author, count) values ('Война и мир', 'А.С.Пушкин', 10000)")

# Ввод пользователя
print("Заполните занчения")
name = input("Введите название книги: ")
author = input("Введите автора: ")
count = input("Введите количество страниц: ")
c.execute("insert into books (name, author, count) values (?, ?, ?)", (name, author, count))


print("Вывод всех данных:")
c.execute("select * from books")
for row in c.fetchall():
    print(row)

# Вывод с сортировкой по автору
print("Вывод с сортировкой по автору:")
c.execute("select * from books order by author")
for row in c.fetchall():
    print(row)

# Книга с самым болшим количеством страниц
print("Книга с самым большим количеством страниц:")
c.execute("select * from books order by count desc limit 1")
print(c.fetchone())

# Найти все книги в названии которых есть слово три
print("Книги со словом три в названии:")
c.execute("select * from books where name like '%три%'")
for row in c.fetchall():
    print(row)
    
# Найти книги с количеством страниц от 100 до 200
print("Книги с количеством страниц от 100 до 200:")
c.execute("select * from books where count <= 200 and count >= 100")
for row in c.fetchall():
    print(row)
    
# Найти книги А.С.Пушкина с количством страниц меньше 100
print("Книги Пушкина с количством страниц меньше 100:")
c.execute("select * from books where author = 'А.С.Пушкин' and count <= 100")
for row in c.fetchall():
    print(row)
    
# Найти книги определенного автора
find_author = input("Введите автора: ")
c.execute("select * from books where author = ?", (find_author,))
for row in c.fetchall():
    print(row)
    
# Изменить информацию о книге
find_id = input("Введите номер книги которую хотите изменить: ")
c.execute("select * from books where number = ?", (find_id))
id_count = c.fetchone()
if len(id_count) != 0:
    new_name = input("Новое название книги: ")
    new_author = input("Новое автор книги: ")
    new_count = input("Новое количество страниц: ")

    c.execute("update books set name = ?, author = ?, count = ? where number = ?", (new_name, new_author, new_count, find_id))
    
    # Удаление
    c.execute("delete from books where number = ?", (find_id))
else:
    print("Такой книги нету!")

conn.commit()
conn.close()