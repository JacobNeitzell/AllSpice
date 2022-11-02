import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: [],
  favorites: [],
  /** @type {import('./models/Recipe.js').Recipe || null} */
  activeRecipe: null,
  activeRecipeId: null,

  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: [],

  categories: [
    { name: "specialtyCoffee", id: 1 },
    { name: "asian", id: 2 },
    { name: "mexican", id: 3 },
    { name: "italian", id: 4 },
    { name: "mexican", id: 5 },
  ]


})
