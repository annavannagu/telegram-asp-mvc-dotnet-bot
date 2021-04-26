import requests
from bs4 import BeautifulSoup
import os
import pyodbc 

# url = 'https://www.worldometers.info/geography/flags-of-the-world/' # url для второй страницы
# r = requests.get(url)

# soup = BeautifulSoup(r.content,features="html.parser")
# flag_list = soup.find_all('div', {'class': 'col-md-4'})
# i = 1
# for flag in flag_list:
#     try:
#         file_name = flag.find('div').find('div').text
#         print(i, file_name)
#         i+=1

    
#         file_link = 'https://www.worldometers.info' + flag.find('a').get('href')
#         response = requests.get(file_link)
#         print(file_link)
#         file = open(file_name + ".gif", "wb")
#         file.write(response.content)
#         file.close()
#     except:
#         print('None')

conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=ANNAW10\SQLEXPRESS;'
                      'Database=telegrambot;'
                      'Trusted_Connection=yes;')



folder_path = 'E:\Repos\\flags'

cursor = conn.cursor()
# cursor.execute('SELECT * FROM telegrambot.dbo.Players')
number = 1
for file in os.listdir(folder_path):
    # cursor = conn.cursor()
    # print(os.fsdecode(file))
    cursor.execute('INSERT INTO telegrambot.dbo.Flags(Number, ImageName, Country) VALUES(' + str(number) + ', \'' + os.fsdecode(file) + '\', \'' + os.fsdecode(file)[:-4] + '\')')
    # print('INSERT INTO telegrambot.dbo.Flags(Number, ImageName, Country) VALUES(' + str(number) + ', \'' + os.fsdecode(file) + '\', \'' + os.fsdecode(file)[:-4] + '\')')
    
    number += 1

conn.commit()

# for row in cursor:
#     print(row)
print('Ready')