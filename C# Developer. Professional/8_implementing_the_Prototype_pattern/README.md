# 8hw

#Домашнее задание
Реализуем паттерн "Прототип"

Цель:
Создать иерархию из нескольких классов, в которых реализованы методы клонирования объектов по шаблону проектирования "Прототип".

Описание/Пошаговая инструкция выполнения домашнего задания:
+Придумать и создать 3-4 класса, которые как минимум дважды наследуются и написать краткое описание текстом.
+Создать свой дженерик интерфейс IMyCloneable для реализации шаблона "Прототип".
+Сделать возможность клонирования объекта для каждого из этих классов, используя вызовы родительских конструкторов.
+Составить тесты или написать программу для демонстрации функции клонирования.
+Добавить к каждому классу реализацию стандартного интерфейса ICloneable и реализовать его функционал через уже созданные методы.
Написать вывод: какие преимущества и недостатки у каждого из интерфейсов: IMyCloneable и ICloneable.

#Описание классов
Tree   - базовый класс, имеет поле TreeColor, реализует интерфейсы ICloneable,IMyCloneable<T>
Branch - класс расширяющий Tree, добавляет поле BranchColor и NumberOfBranch
LeafAutumn  - класс расширяющий Branch, добавляет поле LeafColor и NumberOfLeaf
Все классы являются реализациями шаблона Прототип.