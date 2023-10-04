from time import mktime, strptime, gmtime
import datetime

dt_object = strptime("Fri Aug 7 06:05:04 2009")
print("Ставим дату:", dt_object)

print(datetime.datetime.combine(datetime.date(gmtime().tm_year, gmtime().tm_mon, gmtime().tm_mday), datetime.time(dt_object.tm_hour, dt_object.tm_min)))