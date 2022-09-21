import { SuperHeroService } from './Services/super-hero.service';
import { SuperHero } from './Models/super-hero';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SuperHero.UI';
  heroes: SuperHero[] = [];
  heroToEdit?: SuperHero;
  columnsToDisplay =['name','firstName','lastName','place','button'];

  constructor(private superHeroService : SuperHeroService){}

  ngOnInit(): void {
    this.superHeroService
    .getSuperHeros()
    .subscribe((result:SuperHero[])=>(this.heroes = result));
    //console.log(this.heroes);
  }
  updateHeroList(heroes: SuperHero[]){
    this.heroes = heroes;
  }

  initNewHero(){
    this.heroToEdit = new SuperHero();
  }
  editHero(hero: SuperHero){
     this.heroToEdit = hero;
  }
}
