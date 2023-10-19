import pickle

class Car:
    def __init__(self, mark, power, year):
        self.mark = mark
        self.power = power
        self.year = year

    def __str__(self):
        return "Марка: {}, Мощность: {}, Год производства: {}".format(self.mark, self.power, self.year)


class PassengerCar(Car):
    def __init__(self, mark, power, year, passenger_count):
        super().__init__(mark, power, year)
        self.passenger_count = passenger_count
        # map(spare, year_to_fix)
        self.book = {}

    # Геттер
    def getSpareYearByName(self, spare):
        return self.book.get(spare)
    
    # Сеттер
    def addSpare(self, spare, year):
        self.book[spare] = year

    def printBook(self):
        print("Ремонтная книжка:")
        for spare, year in self.book.items():
            print("Запчасть: {} такого года замены: {}".format(spare, year))

    def __str__(self):
        return "{}, Количество пассажиров: {}".format(super().__str__(), self.passenger_count)


car = Car("Lada", 1, 1900)
passCar = PassengerCar("BMW", 600, 2023, 7)

with open('cars.pickle', 'wb') as file:
    pickle.dump(car, file)
    pickle.dump(passCar, file)
