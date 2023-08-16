using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[] commands = Console.ReadLine()
                .Split(":")
                .ToArray();

            while(commands[0] != "course start")
            {
                switch(commands[0])
                {
                    case "Add":
                        string lessonToAdd = commands[1];
                        AddLesson(lessonToAdd, lessons);
                        break;
                    case "Insert":
                        string lessonToInsert = commands[1];
                        int indexToInsert = int.Parse(commands[2]);
                        InsertLesson(lessonToInsert, indexToInsert, lessons);
                        break;
                    case "Remove":
                        string lessonToRemove = commands[1];
                        RemoveLesson(lessonToRemove, lessons);
                        break;
                    case "Swap":
                        string firstLessonToSwap = commands[1];
                        string secondLessonToSwap = commands[2];
                        SwapLessons(firstLessonToSwap, secondLessonToSwap, lessons);
                        break;
                    case "Exercise":
                        string exerciseToAdd = commands[1];
                        AddExercise(exerciseToAdd, lessons);
                        break;
                }

                commands = Console.ReadLine()
                .Split(":")
                .ToArray();
            }

            int lessonsCounter = 1;
            foreach (string lesson in lessons)
            {
                Console.WriteLine($"{lessonsCounter}.{lesson}");
                lessonsCounter++;
            }
        }

        private static void AddLesson(string lessonToAdd, List<string> lessons)
        {
            if(!lessons.Contains(lessonToAdd))
            {
                lessons.Add(lessonToAdd);
            }
        }

        private static void InsertLesson(string lessonToInsert, int indexToInsert, List<string> lessons)
        {
            if (!lessons.Contains(lessonToInsert))
            {
                lessons.Insert(indexToInsert, lessonToInsert);
            }
        }

        private static void RemoveLesson(string lessonToRemove, List<string> lessons)
        {
            if (lessons.Contains(lessonToRemove))
            {
                lessons.Remove(lessonToRemove);
                if (lessons.Contains($"{lessonToRemove}-Exercise"))
                {
                    lessons.Remove($"{lessonToRemove}-Exercise");
                }
            }
        }

        private static void SwapLessons(string firstLessonToSwap, string secondLessonToSwap, List<string> lessons)
        {
            if (lessons.Contains(firstLessonToSwap) && lessons.Contains(secondLessonToSwap))
            {
                int firstLessonToSwapIndex = lessons.FindIndex(lessons => lessons == firstLessonToSwap);
                int secondLessonToSwapIndex = lessons.FindIndex(lessons => lessons == secondLessonToSwap);
                string tempLesson = firstLessonToSwap;

                lessons[firstLessonToSwapIndex] = secondLessonToSwap;
                lessons[secondLessonToSwapIndex] = tempLesson;

                if(lessons.Contains($"{firstLessonToSwap}-Exercise"))
                {
                    tempLesson = $"{firstLessonToSwap}-Exercise";
                    lessons.Remove($"{firstLessonToSwap}-Exercise");
                    lessons.Insert(secondLessonToSwapIndex + 1, tempLesson);
                }
                if(lessons.Contains($"{secondLessonToSwap}-Exercise"))
                {
                    tempLesson = $"{secondLessonToSwap}-Exercise";
                    lessons.Remove($"{secondLessonToSwap}-Exercise");
                    lessons.Insert(firstLessonToSwapIndex + 1, tempLesson);
                }
            }
        }

        private static void AddExercise(string exerciseToAdd, List<string> lessons)
        {
            if (!lessons.Contains($"{exerciseToAdd}-Exercise"))
            {
                if(!lessons.Contains(exerciseToAdd))
                {
                    lessons.Add(exerciseToAdd);
                    lessons.Add($"{exerciseToAdd}-Exercise");
                }
                else
                {
                    int indexLesson = lessons.FindIndex(lesson => lesson == exerciseToAdd);
                    lessons.Insert(indexLesson + 1, $"{exerciseToAdd}-Exercise");
                }

            }
        }
    }
}
