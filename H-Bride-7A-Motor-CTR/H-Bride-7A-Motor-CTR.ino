/*==========================================================================
//  Author      : Handson Technology
//  Project     : Arduino Uno with H-Bride 7A Motor Driver
//  Description : XY160D 7A high Power H-Bridge motor Driver Module
//  Source-Code : H-Bride-7A-Motor-CTR.ino
//  Program: Control 2 DC motors using L298N H Bridge Driver
//==========================================================================
*/

const int IN1=D3;
const int IN2=D4;
const int ENA=D1;

const int IN3=D5;
const int IN4=D6;
const int ENB=D2;

void setup() {
     pinMode(IN1, OUTPUT);
     pinMode(IN2, OUTPUT);
     pinMode(ENA, OUTPUT);
     
     pinMode(IN4, OUTPUT);
     pinMode(IN3, OUTPUT);
     pinMode(ENB, OUTPUT);
     Motor1_Brake();
     Motor2_Brake();

     delay(100);
     Motor1_Forward(100);
     Motor2_Forward(100);
     delay(160);
}

void loop() {
 Motor1_Forward(100);
 Motor2_Forward(100);
// Motor1_Brake();
// Motor2_Brake();
// delay(100);
// Motor1_Backward(50);
// Motor2_Backward(50);
// delay(1000); 
}

void Motor1_Forward(int Speed) 
{
     digitalWrite(IN1,HIGH); 
     digitalWrite(IN2,LOW);  
     analogWrite(ENA,Speed);
}
  
void Motor1_Backward(int Speed) 
{    
     digitalWrite(IN1,LOW); 
     digitalWrite(IN2,HIGH);  
     analogWrite(ENA,Speed);
}
void Motor1_Brake()      
{
     digitalWrite(IN1,LOW); 
     digitalWrite(IN2,LOW); 
}     
void Motor2_Forward(int Speed) 
{
     digitalWrite(IN3,HIGH); 
     digitalWrite(IN4,LOW);  
     analogWrite(ENB,Speed);
}
  
void Motor2_Backward(int Speed) 
{    
     digitalWrite(IN3,LOW); 
     digitalWrite(IN4,HIGH);  
     analogWrite(ENB,Speed);
}
void Motor2_Brake()
{
     digitalWrite(IN3,LOW); 
     digitalWrite(IN4,LOW); 
}
