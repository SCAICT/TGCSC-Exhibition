int a_arr[8]={A0,A1,A2,A3,A4,A5,A6,A7};
void setup() {
  Serial.begin(9600);
  for(int j=0;j<8;j++){
    pinMode(a_arr[j],INPUT);
  }
}

void loop() {
  String tmp = "";
  for(int i=0;i<7;i++){
    tmp+=String(analogRead(a_arr[i]));
    tmp+=',';
  }
    tmp+=String(analogRead(a_arr[7]));
    Serial.println(tmp);
  delay(500);
}
