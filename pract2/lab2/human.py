class Human:
    default_name = "Иван Иванов"
    default_age = 21

    def __init__(self, name=default_name, age=default_age):
        self.name = name
        self.age = age
        # Приватные
        self._money = 0
        self._house = None
    
    def info(self):
        print("Имя: {} Возраст: {} Жилье: {} Баланс: {}".format(self.name, self.age, "Нету" if self._house is None else self._house.getArea(), self._money))
        
    @staticmethod
    def default_info():
        print("Имя: {} Возраст: {}".format(Human.default_name, Human.default_age))

    def _make_deal(self, house, price):
        if self._money <= 0:
            print("Отрицательный баланс!")
        else:
            if self._money < price:
                print("Не хватает денег!")
            else:
                self._money -= price
                self._house = house
                print("Дом куплен")
    
    # Работай в шахте
    def earn_money(self, money=1000):
        print("Поработали в шахте. Заработали {}".format(money))
        self._money += money

    # Скидка в процентах(discount = 30)
    def buy_house(self, house, discount):
        self._make_deal(house, house.final_price(discount))



class House:
    def __init__(self, area=10, price=500):
        self._area = area
        self._price = price
        
    def final_price(self, discount):
        return self._price - (self._price * (discount / 100))

    def getArea(self):
        return self._area
    
class SmallHouse(House):
    def __init__(self, area=40, price=4000):
        House.__init__(self, area, price)


print("Вызовите справочный метод default_info() для класса Human")
Human.default_info()

print("Создайте объект класса Human")
human = Human("Егор", 35)

print("Выведите справочную информацию о созданном объекте (вызовите метод info())")
human.info()

print("Создайте объект класса SmallHouse")
sHouse = SmallHouse()

print("Попробуйте купить созданный дом, убедитесь в получении предупреждения")
human.buy_house(sHouse, 0)

print("Поправьте финансовое положение объекта - вызовите метод earn_money()")
human.earn_money()

print("Снова попробуйте купить дом")
human.buy_house(sHouse, 0)
human.earn_money(5000)
human.buy_house(sHouse, 0)

print("Посмотрите, как изменилось состояние объекта класса Human")
human.info()