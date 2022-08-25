from flask import Flask, after_this_request, render_template, request,redirect

app = Flask(__name__)

@app.route('/')
def hello():
    return render_template("index.html")

if __name__ == "__main__":
    app.run(host = "0.0.0.0", port=8020, debug=True)