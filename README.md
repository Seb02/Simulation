# Simulation de vie
Ce projet s'inscrit dans le cours de programmation orientée objet de 3e bachelier de l'ECAM 

Plus d'informations sur ce projet dans [Projet 2022-Ecosystème](https://quentin.lurkin.xyz/courses/poo/projet2022/index.html)
## Contenu du répositoire

* Un fichier *Simulation.cs* contenant la classe "Simulation" qui modélise la simulation dans laquelle évoluent les différents types d'objets (carnivores, herbivores, plantes). La classe implémente l'interface ["IDrawable"](https://learn.microsoft.com/en-us/previous-versions/windows/xna/bb197416(v=xnagamestudio.42))

* Un fichier *DrawableObject.cs* contenant une classe appelée "DrawableObject" qui représente un objet pouvant être dessiné sur le plan.

* Un fichier *SimulationObject.cs* contenant une classe abstraite appelée "SimulationObject" qui hérite de la classe "DrawableObject". La classe "SimulationObject" définit une structure de données et des méthodes pour modéliser un objet dans la simulation.


* Un fichier *LifeForm.cs* contenant une classe abstraite appelée "LifeForm" qui hérite de la classe "SimulationObject". La classe "LifeForm" définit plusieurs méthodes et propriétés pour modéliser une forme de vie dans la simulation.


* Un fichier *Animal.cs* contenant une classe abstraite appelée "Animal" qui hérite de la classe "LifeForm". La classe "Animal" définit plusieurs méthodes et propriétés pour modéliser un animal dans la simulation.


* Un fichier *Plant.cs* contenant une classe abstraite appelée "Plant" qui hérite de la classe "LifeForm". La classe "Plant" définit plusieurs méthodes et propriétés pour modéliser un plante dans la simulation.

* Un fichier *Carnivore.cs* contenant la classe "Carnivore" qui hérite de la classe "Animal" et qui modélise un animal carnivore dans la simulation.

* Un fichier *Herbivore.cs* contenant la classe "Herbivore" qui hérite de la classe "Animal" et qui modélise un animal herbivore dans la simulation.

* Un fichier *Meat.cs* contenant une classe "Meat" qui hérite de la classe "SimulationObject" et qui modélise de la viande dans la simulation.

* Un fichier *OrganicWaste.cs* contenant une classe "OrganicWaste" qui hérite de la classe "SimulationObject" et qui modélise des déchets organiques dans la simulation.



* Un fichier de projet *Simulation.csproj* qui définit les propriétés de l'application, telles que son nom, son identifiant, sa version et les plateformes cibles pour lesquelles elle sera construite.


* Un fichier de projet *test_graphics.csproj* définit les paramètres du projet

* Un fichier *MauiProgram.cs* qui définit la classe statique "MauiProgram"

* Un fichier *App.xaml.cs* contenant une classe "App" qui hérite de la classe Application La classe initialise les composants de l'application et définit la page principale de l'application 

* Un fichier *App.xaml.cs* qui définit une page de contenu utilisant une vue de graphics pour afficher ce contenu

* Un fichier *AppShell.xaml.cs* qui définit la classe "AppShell"




## Description du fonctionnement de la simulation

L’objectif de ce travail est la réalisation d'une simulation représentant un écosystème dans lequels les formes de vie ont été simplifiées.
Les règles qui régissent la simulation sont les suivantes :

* Le monde est représenté par un plan 2D.
* Toute les formes de vie ont des points de vie et des réserves d'énergie.
* Les réserves d'énergie diminuent avec le temps.
* Lorsqu'une forme de vie n'a plus d'énergie, elle convertit ses points de vie en énergie.
* Une forme de vie qui n'a plus de point de vie meurt. Les animaux deviennent de la viande. Les plantes deviennent des déchets organiques.
* Les animaux peuvent se déplacer. Les plantes ne le peuvent pas.
* La viande devient un déchet organique après un certain temps.
* Une forme de vie doit se nourrir pour remplir ses réserves d'énergie.
* Les carnivores se nourrissent de viande. Ils doivent donc tuer d'autre animaux. Ils doivent attaquer pour faire perdre tous les points de vie de leurs proies. Pour attaquer, les carnivores doivent rentrer en contact avec leur cible.
* Les herbivores mangent des plantes.
* Les plantes se nourrissent de déchets organiques.
* Les animaux laissent régulièrement des déchets organiques derrière eux.
* Une forme de vie doit se reproduire.
* Pour les animaux, un mâle et une femelle doivent entrer en contact. Après une période de gestation, un petit naît près de la femelle.
* Les plantes se répandent, de nouvelles plantes naissent dans les alentours d'une plante existante
* Autour d'une forme de vie, il y a plusieurs zones. Ces zones sont circulaires et sont caractérisées par leur rayon.
* La zone de vision est la zone dans laquelle un animal peut voir (des proies, de la nourriture, des prédateurs).
* la zone de contact est la zone dans laquelle on considère que le contact est possible. Un prédateur peut attaquer une proie. Un herbivore peut manger une plante. Un mâle et une femelle peuvent se reproduire...
* Pour les plantes, la zone de racines est la zone dans laquelle elle peut consommer les déchets organiques.
* Et toujours pour les plantes, la zone de semis est la zone dans laquelle de nouvelles plantes peuvent apparaître autour d'une plante existante.

## Diagramme de classe

## Diagramme de séquence 

## Description de deux principes SOLID

1. Single Responsibility Principle : Une classe ne doit avoir qu'une seule et unique responsabilité.
chaque classe ou module a une fonction unique et spécifique, nous évitons donc d'inclure des responsabilités différentes dans la même classe en décomposant les classes en parties plus petites, chacune ayant une responsabilité unique. 

2. Open/Closed Principle : Les entités doivent être ouvertes à l'extension et fermées à la modification. Il est en effet aisé de créer des classes représentant de nouvelles espèces qui héritent de "Carnivore", "Herbivore" ou "Plant" sans pour autant modifier une entité existante. Nous pouvons par exemple créer une classe "tigre" qui hérite de "Carnivore". Le tigre aura un "visionRadius" de 12, un "contacRadius" de 5 une "Energy" de 18 et une "Life" de 25.

namespace Simulation
{
    public class Tigre : Carnivore
    {
        public Tigre(double x, double y, Simulation simulation) : base(x, y, simulation, visionRadius: 12, contactRadius: 5, Energy: 18, Life: 25)
        {
        }
    }
}
