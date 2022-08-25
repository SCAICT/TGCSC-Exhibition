import pymysql
db = pymysql.connect(host='steal.tyc4d.tw',user='user',passwd="u",db='mydb')
cursor = db.cursor()
cursor.execute("SELECT * from users")
result = cursor.fetchall()
for i in result:
    print(i[0],i[1],i[2],i[3])
db.close()