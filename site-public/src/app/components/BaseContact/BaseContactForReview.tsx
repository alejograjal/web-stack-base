import BaseContact from './BaseContact';
import { BaseContactProps } from './BaseContact';
import type { BranchForm } from '@sections/ReviewsSection/ReviewSchema';

const BaseContactForReview = (props: BaseContactProps<BranchForm>) => (
    <BaseContact {...props} />
);

export default BaseContactForReview;
