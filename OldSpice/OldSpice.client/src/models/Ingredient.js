export class Ingredient {
  constructor(data) {
    this.id = data.id
    this.recipeId = data.recipeId
    this.name = data.name
    this.quantity = data.quantity
    this.creatorId = data.creatorId
  }
}