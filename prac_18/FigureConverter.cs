using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.prac_18
{
    public class FigureConverter : Newtonsoft.Json.JsonConverter
    {
        // 
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Figure).IsAssignableFrom(typeToConvert);
        }

        // Создается JObject, в который добавляются поля, сначала общие, потом специфические для конкретного типа
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Figure figure = (Figure)value;
            JObject jsonObject = new JObject
            {
                ["Type"] = figure.GetType().Name,
                ["x"] = figure.x,
                ["y"] = figure.y
            };

            if (figure is Circle circle)
            {
                jsonObject["Radius"] = circle.radius;
            }
            else if (figure is Rectangle rectangle)
            {
                List<PointFigure> listOfPOints = rectangle.GetPoints();
                jsonObject["pointLeftUp"] = listOfPOints[0].ToString();
                jsonObject["pointRightUp"] = listOfPOints[1].ToString();
                jsonObject["pointLeftDown"] = listOfPOints[2].ToString();
                jsonObject["pointRightDown"] = listOfPOints[3].ToString();
            }
            else if (figure is Triangle triangle)
            {
                List<PointFigure> listOfPoints = triangle.GetPoints();
                jsonObject["point1"] = listOfPoints[0].ToString();
                jsonObject["point2"] = listOfPoints[1].ToString();
                jsonObject["point3"] = listOfPoints[2].ToString();
            }
            
            jsonObject.WriteTo(writer);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            string type = jsonObject["Type"].ToString();

            // в зависимости от типа объекта создать фигуру этого типа
            Figure figure;
            switch (type)
            {
                case "Circle":
                    figure = new Circle();
                    break;
                case "PointFigure":
                    figure = new PointFigure();
                    break;
                case "Triangle":
                    figure = new Triangle();
                    break;
                case "Rectangle":
                    figure = new Rectangle();
                    break;
                default:
                    throw new NotSupportedException($"Тип {type} не поддерживается");
            };

            serializer.Populate(jsonObject.CreateReader(), figure); // Заполняем объект данными из JSON
            return figure;
        }
    }
}

