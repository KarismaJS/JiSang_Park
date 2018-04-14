#include <stdio.h>

int add(int num1, int num2)
{
 return num1 + num2;
}

 int sub(int num1 , int num2)
 {
   return num1 - num2;
 }

int Mul(int num1 , int num2)
{
 retrun num1 * num2;
}

int division(int num1, int num2){
 return num1 / num2;
}

void title(){

  printf("메뉴를 선택하세요\n");
  printf("1.더하기\n");
  printf("2.빼기\n");
  printf("3.곱하기\n");
  printf("4.나누기\n");
  printf("5.종료\n");
  printf("선택 : ");
  
 }
 
}

double calculation(int input, int num1, int num2){
 double result=0;
 switch(input){
   case 1: result = add(num1, num2);
  case 2: result = sub(num1, num2);
  case 3: result = Mul(num1, num2);
  case 4 : result = division(num1, num2);
 }
 return result;
 }


int main(){
 
 int input=0; //입력변수
 int num1=0, num2=0;
 
 printf("Open Sourse HomeWork...\n");
 printf("사칙연산이 가능한 프로그램입니다.\n");
 
 while(input != 5){
  title();
  scanf("%d", &input);
  if(input == 5) {
   printf("프로그램을 종료 합니다.");
   break;
  }
  printf("계산을 할 두 정수를 입력하세요 :");
  scanf("%d %d", &num1, &num2);
  
 
 
}
