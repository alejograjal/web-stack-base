import BaseContact, { BaseContactProps } from './BaseContact';
import type { ReviewForm } from '@sections/ReviewsSection/ReviewSchema';

const BaseContactForReview = (props: BaseContactProps<ReviewForm>) => (
    <BaseContact {...props} />
);

export default BaseContactForReview;