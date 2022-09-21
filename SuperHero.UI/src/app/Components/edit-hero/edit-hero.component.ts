import { SuperHeroService } from './../../Services/super-hero.service';
import { SuperHero } from './../../Models/super-hero';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-edit-hero',
  templateUrl: './edit-hero.component.html',
  styleUrls: ['./edit-hero.component.css']
})
export class EditHeroComponent implements OnInit {
  @Input() hero ?: SuperHero;
  @Output() heroesUpdated = new EventEmitter<SuperHero[]>();
  constructor(private superHeroService : SuperHeroService) { }

  ngOnInit(): void {
  }

  updateHero(hero:SuperHero){
    this.superHeroService
    .updateSuperHero(hero)
    .subscribe((heroes: SuperHero[])=>this.heroesUpdated.emit(heroes));
  }

  createHero(hero:SuperHero){
    this.superHeroService
    .createSuperHero(hero)
    .subscribe((heroes: SuperHero[])=>this.heroesUpdated.emit(heroes));
  }

  deleteHero(hero:SuperHero){
    this.superHeroService
    .deleteSuperHero(hero)
    .subscribe((heroes: SuperHero[])=>this.heroesUpdated.emit(heroes));
  }

}
