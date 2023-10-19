import sqlite3
from sqlite3 import Error

conn = sqlite3.connect('SGU.db')
c = conn.cursor()

c.execute('''create table if not exists students (
                number integer primary key autoincrement not null,
                class string,
                fio string,
                sex integer default 0,
                age integer,
                math_check real,
                geography_check real,
                check (sex IN (0, 1)),
                check (math_check <= 5 and math_check >= 2),
                check (geography_check <= 5 and geography_check >= 2))''')

c.execute('''create table if not exists bibl (
                student_number integer not null,
                name string,
                author string,
                foreign key (student_number) references students (number))''')

c.execute('''create table if not exists teachers (
                number integer primary key autoincrement not null,
                fio string,
                class string,
                discipline string)''')

# Проверка создания таблицы
c.execute("PRAGMA table_info(bibl)")
if c.fetchall():
    print("Таблица bibl создана")
else:
    print("Таблица bibl не создана")

# Ввод данны в таблицу студентов
try:
    c.execute("insert into student (class, fio, sex, age, math_check, geography_check) value (?, ?, ?, ?, ?, ?)", (11, "Вася Пупкин", 0, 15, 3.4, 4.3))
except Error as e:
    print(e)

# Ввод через переменные (все данные)
try:
    a = ('7а', 'Прокофьев', 1, 14, '3.4', '4.8')
    b = ('7а', 'Кировкина', 0, 13, '5.9', '4.9')
    c.execute("INSERT INTO students (class, fio, sex, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?, ?)", a)
    c.execute("INSERT INTO students (class, fio, sex, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?, ?)", b)
except Error as e:
    print(e)

# Ввод через переменные  (данные без информации о поле)
try:
    c_tmp = ('7а', 'Михайлова', 13, 4.9, 4.9)
    c.execute("INSERT INTO students (class, fio, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?)", c_tmp)
except Error as e:
    print(e)

# Какие проблемы возникнут при вводе следующих данных:
try:
    d = (25, "7а", "Кировкина", 6, 13, 4.4, 4.2)
    e = (25, "7а", "Сомов", 1, 0, 4.1, 4.1)
    c.execute("INSERT INTO students (number, class, fio, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?)", d)
    c.execute("INSERT INTO students (number, class, fio, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?)", e)
except Error as e:
    print(e)

# Загрузите информацию из приложенных текстовых файлов.
with open("attaches/bibl.txt", "r") as file:
    rows = file.readlines()

    for row in rows:
        c.execute("insert into bibl (student_number, name, author) values (?, ?, ?)", row.split(";"))

with open("attaches/teachers.txt", "r", encoding="utf-8") as file:
    rows = file.readlines()

    for row in rows:
        c.execute("insert into teachers (number, fio, class, discipline) values (?, ?, ?, ?)", row.split(";"))

with open("attaches/students.txt", "r", encoding="utf-8") as file:
    rows = file.readlines()

    for row in rows:
        c.execute("insert OR IGNORE into students (number, class, fio, sex, age, math_check, geography_check) VALUES (?, ?, ?, ?, ?, ?, ?)", row.split(";"))


# Заполнение данных в таблицы (ведите нового студента в 10а)
c.execute("insert into students (class, fio, sex, age, math_check, geography_check) values ('10а', 'Иван', 1, 16, 4.3, 3.2)")

# Исправление данных в таблицах (измените класс с 10а на 11а во всех таблицах)
c.execute("update students SET class='11а' WHERE class='10а'")
c.execute("update teachers SET class='11а' WHERE class='10а'")

# Удаление данных из таблиц (удалите учителя Боярин)
c.execute("delete from teachers where fio='Боярин'")

# Поиск информации (о ученике, о том какие книги ученик взял в библиотеке, в каких классах преподает учитель)
c.execute("select s.fio, b.name, t.fio from students as s join bibl as b on s.number = b.student_number join teachers as t on s.class = t.class")
print(c.fetchall())

# Выведите на экран записи о всех учениках
c.execute("select * from students")
for row in c.fetchall():
    print(row)

# Вывести записи о имени и возрасте учеников
c.execute("select fio, age from students")
for row in c.fetchall():
    print(row)

# Вывести информацию о девушках
c.execute("select * from students where sex = 0")
for row in c.fetchall():
    print(row)

# Подсчитать количество девушек
c.execute("select count(*) from students WHERE sex = 0")
print("Всего девушек: {}".format(c.fetchone()))

# Вывести информацию о том какие книги взял ученик в библиотеке
c.execute("select s.fio, b.name FROM students as s join bibl as b on s.number = b.student_number")
for row in c.fetchall():
    print("{} взял {}".format(row[0], row[1]))







# Определить сколько книг взял каждый ученик в библиотеке
c.execute("select s.fio, count(b.name) from students as s join bibl as b on s.number = b.student_number group by fio")
for row in c.fetchall():
    print("{} взял {} книг".format(row[0], row[1]))


# Создать запрос о том сколько книг взял конкретный ученик
fio = "Иванов"
c.execute('select s.fio, count(b.name) from students as s join bibl as b on s.number = b.student_number where s.fio = ? limit 1', (fio,))
print("Ученик {} взял {} книг".format(fio, c.fetchone()))

# Создать запрос о том в каких классах преподает конкретный учитель
fio = 'Учитель'
c.execute('select fio, class from teachers where fio = ?', (fio,))
print("Учитель {} работает в {} классах".format(fio, c.fetchone()))

# Создать запрос о том в скольких классах преподает конкретный учитель
c.execute('select fio, count(class) from teachers where fio = ?', (fio,))
print("Учитель {} работает в {} классах".format(fio, c.fetchone()))

# Вывести список учеников конкретного учителя
c.execute('select t.fio, s.fio from teachers as t join students as s on s.class = s.class where t.fio = ? group by s.fio', (fio,))
for row in c.fetchall():
    print("У уичтеля {} есть такой ученик: {}".format(fio, row))

# Определить количество учеников в классах
c.execute('select class, count(fio) from students group by class')
for row in c.fetchall():
    print("В {} классе {} учеников".format(row[0], row[1]))

# Отбор хорошистов и отличников
c.execute('select distinct(fio) from students where math_check >= 4.0 and math_check <= 5.0 and geography_check >= 4.0 and geography_check <= 5.0')
for row in c.fetchall():
    print("Ученик {} хорошо учиться".format(row))

# Отбор девушек отличниц
c.execute('select distinct(fio) from students where math_check >= 4.0 AND geography_check >= 4.0 and sex = 0')
for row in c.fetchall():
    print("Девочка {} хорошо учится".format(row))

# Отбор детей определенного возраста
c.execute('SELECT fio, age from students WHERE age <= 17 and age >= 13')
for row in c.fetchall():
    print("{} {} лет".format(row[0], row[1]))

# Добавьте информацию в bibl. Ученик под номером 51, взял книгу Понкратова "История". Объясните результат
c.execute("INSERT INTO bibl (student_number, name, author) VALUES (51, 'История', 'Понкратов')")

#  Удалите студента Иванова. Объясните результат
c.execute("delete from students where fio = 'Иванов'")

# В таблицу bibl добавьте столбец "Статус" (0-на руках, 1 - вернул). Для всех записей выставите статус - на руках
c.execute("alter table bibl add column status integer default 0")


conn.commit()
conn.close()