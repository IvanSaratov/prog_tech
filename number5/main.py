from bs4 import BeautifulSoup
import requests

URL = "https://course.sgu.ru"
html = requests.get(URL)

soup = BeautifulSoup(html.content, "html.parser")

class_list = set()
tags = {tag.name for tag in soup.find_all()}
for tag in tags:
    for i in soup.find_all(tag):
        if i.has_attr("class"):
            if len(i['class']) != 0:
                class_list.add(" ".join(i['class']))

print(class_list)