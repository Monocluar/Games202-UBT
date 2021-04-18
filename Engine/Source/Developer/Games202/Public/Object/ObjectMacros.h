#pragma once

#define DECLARE_CLASS( TClass, TSuperClass) \
private: \
    TClass& operator=(TClass&&);   \
    TClass& operator=(const TClass&);   \
public:  \
	/** Typedef for the base class ({{ typedef-type }}) */ \
	typedef TSuperClass Super;\
	/** Typedef for {{ typedef-type }}. */ \
	typedef TClass ThisClass;\
private: \
	/** Private move- and copy-constructors, should never be used */ \
	TClass(TClass&&); \
	TClass(const TClass&); \
friend std::shared_ptr<TClass>; \