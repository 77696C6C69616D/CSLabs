/*  Створіть ієрархію класів + використовуючи спадкування.
    У кожному варіанті необхідно написати програму + що ілюструє 
    застосування всіх методів ваших класів. Перш ніж приступити 
    до написання програм + продумайте + які необхідні функції в 
    кожному із класів (може + десь необхідно підрахувати координати + 
    десь площі й об'єми + а десь зберігати прізвища й роки надходження): 
    як у базовому + так й у класах-спадкування. Також продумайте + що 
    варто помістити в закриті (а + можливо + захищені) зміні. Продемонструйте 
    можливість перевизначення методів базового класу в похідному. 
*/
/*  7. Учень в університеті:
        a) студент;
        b) аспірант;
        c) слухач.
*/
namespace CSLab11 {
    class UniStudent {
        public List<string> name = new List<string>();
        public List<string> surname = new List<string>();
        public List<string> date_of_entry = new List<string>();
        public List<string> bday = new List<string>();
        private List<double> avg_entrance_exam_score = new List<double>();        
        public List<string> _name_ {
            get { return name; } }
        public List<string> _surname_ {
            get { return surname; } }
        public List<string> _date_of_entry_ {
            get { return date_of_entry; } }
        public List<string> _bday_ {
            get { return bday; } }
        public List<double> _avg_entrance_exam_score_ {
            get { return avg_entrance_exam_score; } }
        // Функція додавання даних про студента в кінець списка
        public virtual void AddPerson(string _name, string _surname, string _date_of_entry, string _bday, double _avg_entrance_exam_score) {
            name.Add(_name); 
            surname.Add(_surname); 
            date_of_entry.Add(_date_of_entry); 
            bday.Add(_bday); 
            avg_entrance_exam_score.Add(_avg_entrance_exam_score);}
        // Функція видалення даних про студента за індексом
        public virtual void RemovePerson(int index = 0) {
            name.RemoveAt(index); 
            surname.RemoveAt(index); 
            date_of_entry.RemoveAt(index); 
            bday.RemoveAt(index); 
            avg_entrance_exam_score.RemoveAt(index);}
        // Функція виведення даних про студента за індексом
        public virtual void DisplayPersonAt(int index = 0){
            Console.WriteLine("> Імя: " + name[index] +
            "\n> Прізвище: " + surname[index] + 
            "\n> Дата народження: " + bday[index] + 
            "\n> Рік вступу: " + date_of_entry[index] + 
            "\n> Ср. бал вступу: " + avg_entrance_exam_score[index] + "\n");}
        // Функція виведення даних про усіх студентів
        public void DisplayPerson(){
            for (int index = 0; index < name.Count(); ++index)
                DisplayPersonAt(index); } }    
    /*
        Спадкування класу UniStudent класами Student, Aspirant, Listener 
        До класу Aspirant додається поле "research_subject" - предмет дослідження (за https://uk.wikipedia.org/wiki/Аспірант) 
    */
    class Aspirant : UniStudent {         
        private List<string> research_subject = new List<string>();
        private List<double> research_score = new List<double>();
        public List<string> _research_subject_ {
            get { return research_subject; } }  
        public List<double> _research_score {
            get { return research_score; } }  
        /* 
            Наступні функції є переписаними, успадкованими функціями з класу UniStudent, так як було створенно нові поля
            Було видалено поле "avg_entrance_exam_score", замість нього створено поле "research_score"
        */
        public void AddPerson(string _name, string _surname, string _date_of_entry, string _bday, string _research_subject, double _research_score) {
            name.Add(_name); 
            surname.Add(_surname); 
            date_of_entry.Add(_date_of_entry); 
            bday.Add(_bday); 
            research_subject.Add(_research_subject); 
            research_score.Add(_research_score); } 
        public void RemovePerson(int index = 0) {
            name.RemoveAt(index); 
            surname.RemoveAt(index); 
            date_of_entry.RemoveAt(index); 
            bday.RemoveAt(index); 
            research_subject.RemoveAt(index);
            research_score.RemoveAt(index); }          
        public void DisplayPersonAt(int index = 0){
            Console.WriteLine(" Імя: " + name[index] +
            "\n Прізвище: " + surname[index] + 
            "\n День народження:" + bday[index] + 
            "\n Рік вступу" + date_of_entry[index] + 
            "\n Предмет дослідження: " + research_subject[index] + 
            "\n Бали за дослідження: " + research_score[index] + "\n"); }
        public void DisplayPerson(){ 
            for (int index = 0; index < name.Count(); ++index)
                DisplayPersonAt(index); } }                            
    class Student : UniStudent { }
    class Listener : UniStudent { }
    // Програма не має меню, тільки вивід необхідних даних 
    class Program { 
        public static void Main () { 
            Random rnd = new Random();
            Student stu = new Student();
            Aspirant asp = new Aspirant();
            Listener lis = new Listener();
            Console.Clear();
            // Заповнення усіх класів псевдовипадковими даними            
            // Імена згенеровані за допомогою https://blog.reedsy.com/character-name-generator/language/english/
            string[] name = {"Thomas", "Rose", "Sasha", "Richard", "Damon", "Anthony", "Orson", "Troy", "William", "Humbert", "Brooke", "Winton", "Connor", "Barrett", "Ivory", "Bond", "Donald", "Violet", "Hadwin", "Garth" };
            string[] surname = {"Piece", "Hardwells", "Lovecraft", "Dostoyevskiy", "Fitzgerald", "Slater", "Mcdaniel", "Gross", "Stokes", "Fletcher", "Richards", "Mills", "Aguilar", "Holland", "Mccoy", "Cress", "Hodgson", "Bailey", "Motley", "Davis"};            
            string[] bday = {"10.10.2000", "01.05.2000", "08.01.1999", "22.01.1999", "23.02.1999", "16.03.1999", "15.04.1999", "05.02.2000", "03.04.2000", "01.06.2000", "21.11.2000", "23.11.2000", "14.02.2001", "26.04.2001", "03.05.2001", "17.05.2001", "30.05.2001", "13.08.2001", "30.08.2001", "01.12.2001"};            
            string[] research_subject = {"Computer Science", "Math", "Science", "Astronomia", "Philosophy"};
            for (int i = 0; i < 3; ++i) {
                stu.AddPerson(name[rnd.Next(0, name.Count())],
                    surname[rnd.Next(0, surname.Count())], "2018",
                    bday[rnd.Next(0, bday.Count())],
                    rnd.Next(300,500));
                lis.AddPerson(name[rnd.Next(0, name.Count())],
                    surname[rnd.Next(0, surname.Count())], "2018",
                    bday[rnd.Next(0, bday.Count())],
                    rnd.Next(300,500));
                asp.AddPerson(name[rnd.Next(0, name.Count())],
                    surname[rnd.Next(0, surname.Count())], "2018",
                    bday[rnd.Next(0, bday.Count())],
                    research_subject[rnd.Next(0,research_subject.Count())],
                    rnd.Next(120,200));}
            // Демонстрація роботи усіх функцій для кожного класу окремо

            // Console.WriteLine(">> Клас Student: \n");
            // stu.DisplayPerson();            
            // Console.WriteLine(">> Видалення двох студентів (1, 2) з класу Student: ");
            // stu.RemovePerson(0); stu.RemovePerson(1); stu.DisplayPerson();

            // Console.WriteLine(">> Клас Aspirant: \n");
            // asp.DisplayPerson();           
            // Console.WriteLine(">> Видалення студента (2) з класу Aspirant \n>> та виведення його наступника: \n");
            // asp.RemovePerson(1);
            // asp.DisplayPersonAt(1);

            Console.WriteLine(">> Клас Listener: \n");
            lis.DisplayPerson();
            Console.WriteLine(">> Додавання нового студента до класу Listener \n>> та виведення його в термінал: \n");
            lis.AddPerson("Barry", "Chopstick", "23.11.2000", "2018", 400);
            lis.DisplayPersonAt(lis.name.Count()-1); } } }  