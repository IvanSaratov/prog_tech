import sqlite3
import pickle
import car

class ORMMapper:
    def __init__(self, class_name):
        self.class_name = class_name

    def convert_to_db(self):
        founded_vars = [attr for attr in dir(self.class_name) if not callable(getattr(self.class_name, attr)) and not attr.startswith("__")]
        
        plain_sql = "create table if not exists {} (".format(self.class_name.__class__.__name__)
        for var in founded_vars:
            if var == founded_vars[-1]:
                plain_sql += "{} string".format(var)
            else:
                plain_sql += "{} string,".format(var)
        plain_sql += ")"
        conn = sqlite3.connect('car.db')
        c = conn.cursor()
        c.execute(plain_sql)
        conn.commit()
        c.close()


with open('cars.pickle', 'rb') as file:
    car = pickle.load(file)
    print(car)

    orm = ORMMapper(car)
    orm.convert_to_db()