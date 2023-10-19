import sqlite3

def getUnique(table_name, field_name):
    conn = sqlite3.connect('Books.db')
    c = conn.cursor()

    c.execute(f"select {field_name}, count(*) from {table_name} group by {field_name}")
    rows = c.fetchall()

    c.execute(f"select distinct({field_name}), count(distinct({field_name})) from {table_name}")
    unique_rows = c.fetchall()

    conn.commit()
    conn.close()

    return rows, unique_rows


rows, unique_rows = getUnique('books', 'name')

print("Выводим все записи и их количество: ")
for row in rows:
    print("{} : {}".format(row[0], row[1]))

print("Уникальные записи: ")
for row in unique_rows:
    print("{} : {}".format(row[0], row[1]))