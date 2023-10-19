import pickle
import car

with open('cars.pickle', 'rb') as file:
    car = pickle.load(file)
    passCar = pickle.load(file)

    print(car)
    print(passCar)