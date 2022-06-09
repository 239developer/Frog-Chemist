using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONstore : MonoBehaviour
{
    public static string[] elems = {
@"{""symbol"":""H"",""name"":""Водород"",""number"":""1"",""mass"":""1"",""phase"":""газ"",""mp"":""-259.14"",""bp"":""-252.87"",""oxidationStates"":""-1, 0, +1"",""group"":""1(17)""}",
@"{""symbol"":""He"",""name"":""Гелий"",""number"":""2"",""mass"":""4"",""phase"":""газ"",""mp"":""-272.2"",""bp"":""-268.94"",""oxidationStates"":""0"",""group"":""18""}",
@"{""symbol"":""Li"",""name"":""Литий"",""number"":""3"",""mass"":""7"",""phase"":""твердое"",""mp"":""180.54"",""bp"":""1339.85"",""oxidationStates"":""0, +1"",""group"":""1""}",
@"{""symbol"":""Be"",""name"":""Бериллий"",""number"":""4"",""mass"":""9"",""mp"":""1278"",""bp"":""2970"",""oxidationStates"":""0, +2"",""group"":""2""}",
@"{""symbol"":""B"",""name"":""Бор"",""number"":""5"",""mass"":""11"",""mp"":""2075"",""bp"":""3865"",""oxidationStates"":""-3, 0, +3"",""group"":""13""}",
@"{""symbol"":""C"",""name"":""Углерод"",""number"":""6"",""mass"":""12"",""mp"":""-"",""bp"":""-"",""oxidationStates"":""от -4 до +4"",""group"":""14""}", 
@"{""symbol"":""N"",""name"":""Азот"",""number"":""7"",""mass"":""14"",""mp"":""-209.86"",""bp"":""-195.75"",""oxidationStates"":""от -3 до +5"",""group"":""15""}", 
@"{""symbol"":""O"",""name"":""Кислород"",""number"":""8"",""mass"":""16"",""mp"":""-218.35"",""bp"":""-182.96"",""oxidationStates"":""от -2 до +2, -1/2, -1/3, +1/2"",""group"":""16""}",
@"{""symbol"":""F"",""name"":""Фтор"",""number"":""9"",""mass"":""19"",""mp"":""-219.7"",""bp"":""-188.12"",""oxidationStates"":""-1, 0"",""group"":""17""}", 
@"{""symbol"":""Ne"",""name"":""Неон"",""number"":""10"",""mass"":""20"",""mp"":""-248.6"",""bp"":""-246.05"",""oxidationStates"":""0"",""group"":""18""}", 
@"{""symbol"":""Na"",""name"":""Натрий"",""number"":""11"",""mass"":""23"",""mp"":""97.81"",""bp"":""882.95"",""oxidationStates"":""-1, 0, +1"",""group"":""1""}", 
@"{""symbol"":""Mg"",""name"":""Магний"",""number"":""12"",""mass"":""24"",""mp"":""650"",""bp"":""1090"",""oxidationStates"":""0, +2"",""group"":""2""}", 
@"{""symbol"":""Al"",""name"":""Алюминий"",""number"":""13"",""mass"":""27"",""mp"":""660"",""bp"":""2518.82"",""oxidationStates"":""0, +3"",""group"":""13""}",   
@"{""symbol"":""Si"",""name"":""Кремний"",""number"":""14"",""mass"":""28"",""mp"":""1415"",""bp"":""2350"",""oxidationStates"":""-4, 0, +2, +4"",""group"":""14""}", 
@"{""symbol"":""P"",""name"":""Фосфор"",""number"":""15"",""mass"":""31"",""mp"":""44.15"",""bp"":""279.85"",""oxidationStates"":""-3, -1, 0, +1, +3, +5"",""group"":""15""}", 
@"{""symbol"":""S"",""name"":""Сера"",""number"":""16"",""mass"":""32"",""mp"":""112.85"",""bp"":""444.67"",""oxidationStates"":""-2, -1, 0, +1, +2, +4, +6"",""group"":""16""}", 
@"{""symbol"":""Cl"",""name"":""Хлор"",""number"":""17"",""mass"":""35.5"",""mp"":""-100.95"",""bp"":""-34.55"",""oxidationStates"":""-1, 0, +1, +3, +4, +5, +6, +7"",""group"":""17""}", 
@"{""symbol"":""Ar"",""name"":""Аргон"",""number"":""18"",""mass"":""40"",""mp"":""-189.34"",""bp"":""-185.85"",""oxidationStates"":""0"",""group"":""18""}", 
@"{""symbol"":""K"",""name"":""Калий"",""number"":""19"",""mass"":""39"",""oxidationStates"":""0, +1"",""group"":""1""}", 
@"{""symbol"":""Ca"",""name"":""Кальций"",""number"":""20"",""mass"":""40"",""oxidationStates"":""0, +2"",""group"":""2""}", 
@"{""symbol"":""Sc"",""name"":""Скандий"",""number"":""21"",""mass"":""45"",""oxidationStates"":""0, +3"",""group"":""3""}", 
@"{""symbol"":""Ti"",""name"":""Титан"",""number"":""22"",""mass"":""48"",""oxidationStates"":""+2, +3, +4"",""group"":""4""}", 
@"{""symbol"":""V"",""name"":""Ванадий"",""number"":""23"",""mass"":""51"",""oxidationStates"":""0, +2, +3, +4, +5"",""group"":""5""}", 

};

}
