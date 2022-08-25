from urllib.parse import unquote
from flask import Flask, after_this_request, render_template, request,redirect
import pymysql
app = Flask(__name__)

def opendb():
    global db
    db = pymysql.connect(host='steal.tyc4d.tw',user='user',passwd="zxc19201080",db='mydb')
    global cursor
    cursor = db.cursor()
    
@app.route('/')
def hello():
    return "ok"


@app.route('/s/<path:visitPath>',methods=["GET"])
def query(visitPath):
    try:
        sqlquery = unquote(visitPath)
        cont = "";
        opendb()
        cursor.execute(f"{sqlquery}")
        result = cursor.fetchall()
        for i in result:
            cont+=f"{i[0]},{i[1]},{i[2]},{i[3]}<br />"
        db.close()
        return cont
    except:
        print("SQL Error")
        return "Error"
if __name__ == "__main__":
    app.run(host = "0.0.0.0", port=8020, debug=True)