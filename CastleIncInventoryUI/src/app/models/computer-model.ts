export class ComputerModel {
  public id: number = 0;
  public manufacturerId: number = 0;
  public imageUrl: string = "";
  public serialNumber: string = "";
  public status: string = "";
  public manufacturer: string = "";
  public operacionalStatus: string = "";
  public specifications: string = "";
  public purchaseDate: Date = new Date(0);
  public warrantyExpirationDate: Date = new Date(0);
  public assignedOn: Date = new Date(0);
  public assignedTo: string = "";
  public createDate: Date = new Date();
  
  constructor() { }

  public hasAssignedOnDate() {
    return this.assignedOn != new Date(0);
  }
}
