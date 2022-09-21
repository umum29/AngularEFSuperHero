import { environment } from './../../environments/environment';
import { SuperHero } from './../Models/super-hero';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {
  url = "SuperHero"

  constructor(private http: HttpClient) { }

  public getSuperHeros(): Observable<SuperHero[]>{
    return this.http.get<SuperHero[]>(`${environment.apiUrl}/${this.url}`);
  }
  public updateSuperHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.put<SuperHero[]>(`${environment.apiUrl}/${this.url}`, hero);
  }
  public createSuperHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.post<SuperHero[]>(`${environment.apiUrl}/${this.url}`, hero);
  }
  public deleteSuperHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.delete<SuperHero[]>(`${environment.apiUrl}/${this.url}/${hero.id}`);
  }
}
