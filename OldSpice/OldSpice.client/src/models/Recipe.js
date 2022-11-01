import { AppState } from "../AppState.js";
import { Account } from "./Account.js";

export class Recipe {
  constructor(data) {
    this.id = data.id;
    this.title = data.title;
    this.img = data.img;
    this.instructions = data.instructions;
    this.createdAt = data.createdAt;
    this.creator = new Account(data.creator);
    this.creatorId = data.creatorId;
    this.favoriteCount = data.favoriteCount;
    this.category = data.category;
    this.favorited = getFavorite(data.id);
    this.favoriteId = data.favoriteId || null;
  }
}
function getFavorite(id) {
  let fav = AppState.favorites.find((f) => f.recipeId == id);
  if (fav) {
    return true;
  }
  return false;
}

