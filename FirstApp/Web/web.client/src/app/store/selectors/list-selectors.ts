import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ListState } from '../reducers/list-reducer';
import { IList } from '../../interfaces/list';
import { IAvailableList } from '../../interfaces/availableList';
import { RootState } from '../interfaces/root-state';

export const selectListState = (state: RootState) => {
  return state.list;
};

export const selectLists = createSelector(
  selectListState,
  (state: ListState) => state.lists
);

export const selectAvailableListsForCards = createSelector(
  selectListState,
  (state: ListState) => state.availableListsForCards
);

export const selectListById = createSelector(
  selectLists,
  (lists: IList[], props: { id: number }) => lists.find(list => list.id === props.id)
);

export const selectAvailableListById = createSelector(
  selectAvailableListsForCards,
  (availableLists: IAvailableList[], props: { id: number }) => availableLists.find(list => list.id === props.id)
);