import { Action, Reducer } from 'redux';

export interface Recipe{
    id: number;
    title: string;
    description: string;
};

export interface RecipesState{
    recipes: Recipe[];
};

export interface AddRecipeAction{type: 'ADD_RECIPE', recipe: Recipe};
export interface RemoveRecipeAction{type: 'REMOVE_RECIPE', recipe: Recipe};

export type KnownAction = 
    AddRecipeAction |
    RemoveRecipeAction;

export const actionCreators = {
    addRecipe: (recipe: Recipe) => ({type: 'ADD_RECIPE', recipe: recipe} as AddRecipeAction),
    removeRecipe: (recipe: Recipe) => ({type: 'REMOVE_RECIPE', recipe: recipe} as RemoveRecipeAction)
};

export const reducer: Reducer<RecipesState> = (state: RecipesState | undefined, incomingAction: Action): RecipesState => {
    if (state === undefined){
        return { recipes: []};
    }

    const action = incomingAction as KnownAction;
    switch(action.type){
        case 'ADD_RECIPE':
            return { recipes: [...state.recipes, action.recipe] };
        case 'REMOVE_RECIPE':
            return { recipes: state.recipes.filter(recipe => recipe.id !== action.recipe.id) };
        default:
            return state;
    }
}