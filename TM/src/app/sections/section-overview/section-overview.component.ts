import { Component, OnInit } from '@angular/core';
import { ProjectOverview } from 'src/app/models/projectOverview';
import { DBAccessService } from 'src/app/services/dbaccess.service';
import { OverviewEntry } from '../../models/overviewEntry';

@Component({
  selector: 'app-section-overview',
  templateUrl: './section-overview.component.html',
  styleUrls: ['./section-overview.component.css']
})
export class SectionOverviewComponent implements OnInit {
  
  overviewEntries: OverviewEntry [] = [
      ];


  constructor(private dbaccess: DBAccessService) { }

  getTimeInputsGroupedByProject(): void {
    this.dbaccess.getTimeInputsGroupedByProject()
      .subscribe(res => {
        console.log(res);  
        this.overviewEntries = res as OverviewEntry[];
        });
  }

  toggleShow(projectId : number){
    var divElm = document.getElementById("details-"+projectId);
    var btnElm = document.getElementById("detailsbtn-"+projectId);
    if(divElm.style.display == "none"){
      divElm.style.display = "block";
      btnElm.innerHTML = "Hide";
    } else {
      divElm.style.display = "none";
      btnElm.innerHTML = "Show";
    }
    
  }
 

  ngOnInit(): void {
    this.getTimeInputsGroupedByProject();
  }


}
