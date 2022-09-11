package Populations2
  model Animal
  
    // коэффициент прироста популяций
    parameter Real epsilon = 0.7;
    
    // коэффициент прожорливости
    parameter Real gama = 0.7;
    
    // коэффициент прожиточного минимума
    parameter Real lambda = 0.9;
    
    // начальное число особей
    parameter Real StartNumberOfAnimals = 50;
  
  
    //число животных в стае
    Real NumberOfAnimals(start = 10);
    
    // число съеденного ресурса (пока что травы)
    Real NumbEaten(start = 0);
    
    // сытость
    Real Satiety(start = 1);
    
    // сколько планируется съесть -- для выбора режима питания
    Real NutrinionPlan;
    Real AvaliableFood; 
    
    
    // сколько всего существует еды
    ValInput FoodAmount;
    
    // сколько ресурса уничтожено (для передачи в класс Ресурса)
    ValOutput Eaten;
    
    // обновление количества животных в популяции (для передачи в класс Ресурса)
    //ValOutput Animals;
    
  equation
  
    // сколько особь планирует съесть сейчас, в зависимости от наличия ресурса
    NutrinionPlan = gama * NumberOfAnimals;
    AvaliableFood = 0.8 * FoodAmount.Val;
    
    if ( NutrinionPlan > AvaliableFood) then
      NumbEaten = AvaliableFood;
      Satiety = (NumbEaten / NumberOfAnimals) / gama;
     
     else 
       // количество пищи, потребляемой текущей популяцией (в учебнике - это ф-ция F)
       NumbEaten = gama * NumberOfAnimals;
       Satiety = 1;
    end if;
    
    if NumberOfAnimals < 0 then
    NumberOfAnimals = 0;
    end if;
    
    Eaten.Val = NumbEaten;
    
    // функция, по которой происходит развитие популяции -- тут возник вопрос по составлению уравнения
    // lambda - Satiety -- показатель репродуктивности
    der(NumberOfAnimals) = (epsilon - (lambda - Satiety)) * NumberOfAnimals;
    
  end Animal;

  connector ValInput
  input Real Val;
  end ValInput;

  connector ValOutput
  output Real Val;
  end ValOutput;

  model GrassAndDeer
  
    Animal Deer(StartNumberOfAnimals = 70);
    Resource Grass(StartFoodAmount = 35);
  
  equation
  
    connect(Deer.Eaten, Grass.Eaten);
    connect(Grass.AmountAfterRec, Deer.FoodAmount);
    
    

  end GrassAndDeer;

  model Resource
    
    // коэффициент восстановления ресурса
    parameter Real RecoverCoef = 0.7;
    
    // начальное к-во ресурса
    parameter Real StartFoodAmount = 500;
    
    // общее количество ресурса
    Real FoodAmount(start = StartFoodAmount);
    
    // сколько восстановлено
    //Real Recovered;
    
    
    // сколько съедено ресурса
    ValInput Eaten;
    
    //сколько  всего еды стало после восстановления
    ValOutput AmountAfterRec;
    
  
    equation
    
    // сколько ресурса (травы) восстановлено
    //Recovered = FoodAmount * RecoverCoef;
   
    
    // итоговое количество еды после пересчета с учетом съеденного и востановленного
    der(FoodAmount) =  - Eaten.Val + FoodAmount * RecoverCoef;
      if FoodAmount > Eaten.Val * 3 then
    FoodAmount = Eaten.Val * 3;
    end if;
    AmountAfterRec.Val = FoodAmount;// - Eaten.Val + FoodAmount * RecoverCoef;
    
  
  end Resource;
end Populations2;
