import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Covid';

  constructor(private httpClient:HttpClient) 
  {
    


  }



  totalWeek:number = 3;
  covidDate?:Date;
  averageList:any[] = []; 

  realizarConsulta()
  {
    console.log('totalWeek',this.totalWeek);
    console.log('covidDate',this.covidDate);
    
    this.httpClient.get(`https://localhost:7108/api/Countries?startDate=${this.covidDate}&WeekCount=${this.totalWeek}`)
    .subscribe(result => {
      console.log('result',result);
      this.averageList = result as any[];
    })



  }



}
