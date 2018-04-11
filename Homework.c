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


int main(){
 
 int input=0; //입력변수
 
 printf("Open Sourse HomeWork...\n");
 printf("사칙연산이 가능한 프로그램입니다.\n");
 
 while(input != 5){
  title();
  scanf("%d", &input);
 }
 
 
}
